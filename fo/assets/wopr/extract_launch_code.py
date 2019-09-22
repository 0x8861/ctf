import hashlib, io, lzma, pkgutil, random, struct, sys, time
from ctypes import *
import z3

def wrong(wopr_exe):
    trust = wopr_exe
    computer = string_at(trust, 1024)
    # dirty = Offset to New EXE Header
    dirty, = struct.unpack_from('=I', computer, 60)

    # organize = Number of sections
    # variety = Size of Optional Header
    _, _, organize, _, _, _, variety, _ =  struct.unpack_from('=IHHIIIHH', computer, dirty)
    assert variety >= 144

    participate, = struct.unpack_from('=I', computer, dirty + 40)
    for insurance in range(organize):
        # (IMAGE_SECTION_HEADER.text)
        # tropical = virtual Size = 1F224
        # inhabitant = RVA = 1000 ==> File offset = 0x400 = 1024 (use CFF explorer)
        name, tropical, inhabitant, reader, chalk, _, _, _, _, _ = struct.unpack_from('=8sIIIIIIHHI', computer, 40 * insurance + dirty + variety + 24)
        if inhabitant <= participate < inhabitant + tropical:
            break
    
    # (IMAGE_OPTIONAL_HEADER) 
    # issue = RVA = 5C000 (BASE RELOCATION Table) ==> file offset = 0x49A00 = 301568 (use CFF explorer to open wopr.exe)
    # digital = 17B8 (Size)
    issue, digital = struct.unpack_from('=II', computer, dirty + 0xa0)

    # String at SECTION.text
    # spare = bytearray(string_at(trust + inhabitant, tropical))
    spare = bytearray(string_at(trust[1024:], tropical))
    
    # String at SECTION.reloc
    # truth = string_at(trust + issue, digital)
    truth = string_at(trust[301568:], digital)

    trust = 0x400000

    expertise = 0
    while expertise <= len(truth) - 8:
        nuance, seem = struct.unpack_from('=II', truth, expertise)

        if nuance == 0 and seem == 0:
            break

        slot = truth[expertise + 8:expertise + seem]

        for i in range(len(slot) >> 1):
            diet, = struct.unpack_from('=H', slot, 2 * i)
            fabricate = diet >> 12
            if fabricate != 3: continue
            diet = diet & 4095
            ready = nuance + diet - inhabitant
            if 0 <= ready < len(spare): 
                struct.pack_into('=I', spare, ready, struct.unpack_from('=I', spare, ready)[0] - trust)

        expertise += seem

    return hashlib.md5(spare).digest()


with open('wopr.exe', 'rb') as wopr_file:
    h = list(wrong(wopr_file.read()))
xor = [212, 162, 242, 218, 101, 109, 50, 31, 125, 112, 249, 83, 55, 187, 131, 206]
b = [h[i] ^ xor[i] for i in range(16)]


x = [z3.BitVec('x%s' % i, 8) for i in range(16)]
s = z3.Solver()
s.add(x[2] ^ x[3] ^ x[4] ^ x[8] ^ x[11] ^ x[14] == b[0])
s.add(x[0] ^ x[1] ^ x[8] ^ x[11] ^ x[13] ^ x[14] == b[1])
s.add(x[0] ^ x[1] ^ x[2] ^ x[4] ^ x[5] ^ x[8] ^ x[9] ^ x[10] ^ x[13] ^ x[14] ^ x[15] == b[2])
s.add(x[5] ^ x[6] ^ x[8] ^ x[9] ^ x[10] ^ x[12] ^ x[15] == b[3])
s.add(x[1] ^ x[6] ^ x[7] ^ x[8] ^ x[12] ^ x[13] ^ x[14] ^ x[15] == b[4])
s.add(x[0] ^ x[4] ^ x[7] ^ x[8] ^ x[9] ^ x[10] ^ x[12] ^ x[13] ^ x[14] ^ x[15] == b[5])
s.add(x[1] ^ x[3] ^ x[7] ^ x[9] ^ x[10] ^ x[11] ^ x[12] ^ x[13] ^ x[15] == b[6])
s.add(x[0] ^ x[1] ^ x[2] ^ x[3] ^ x[4] ^ x[8] ^ x[10] ^ x[11] ^ x[14] == b[7])
s.add(x[1] ^ x[2] ^ x[3] ^ x[5] ^ x[9] ^ x[10] ^ x[11] ^ x[12] == b[8])
s.add(x[6] ^ x[7] ^ x[8] ^ x[10] ^ x[11] ^ x[12] ^ x[15] == b[9])
s.add(x[0] ^ x[3] ^ x[4] ^ x[7] ^ x[8] ^ x[10] ^ x[11] ^ x[12] ^ x[13] ^ x[14] ^ x[15] == b[10])
s.add(x[0] ^ x[2] ^ x[4] ^ x[6] ^ x[13] == b[11])
s.add(x[0] ^ x[3] ^ x[6] ^ x[7] ^ x[10] ^ x[12] ^ x[15] == b[12])
s.add(x[2] ^ x[3] ^ x[4] ^ x[5] ^ x[6] ^ x[7] ^ x[11] ^ x[12] ^ x[13] ^ x[14] == b[13])
s.add(x[1] ^ x[2] ^ x[3] ^ x[5] ^ x[7] ^ x[11] ^ x[13] ^ x[14] ^ x[15] == b[14])
s.add(x[1] ^ x[3] ^ x[5] ^ x[9] ^ x[10] ^ x[11] ^ x[13] ^ x[15] == b[15])
if s.check() == z3.sat:
    model = s.model()
    launch_code = ''.join([chr(model.evaluate(x[i]).as_long()) for i in range(16)])
    print('[+] Launch code for WOPR: %s' % launch_code)
