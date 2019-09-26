import sys

# Get this data at the address 0x1EFDD0
encrypted_data = [
    0x7A, 0x17, 0x08, 0x34, 0x17, 0x31, 0x3B, 0x25, 0x5B, 0x18, 0x2E, 0x3A,
    0x15, 0x56, 0x0E, 0x11, 0x3E, 0x0D, 0x11, 0x3B, 0x24, 0x21, 0x31, 0x06,
    0x3C, 0x26, 0x7C, 0x3C, 0x0D, 0x24, 0x16, 0x3A, 0x14, 0x79, 0x01, 0x3A,
    0x18, 0x5A, 0x58, 0x73, 0x2E, 0x09, 0x00, 0x16, 0x00, 0x49, 0x22, 0x01,
    0x40, 0x08, 0x0A, 0x14
]

def print_key(key_array):
    key = ''.join([chr(i) for i in key_array])
    sys.stdout.write('\r[*] Current key: %s' % key)
    sys.stdout.flush()


def guess_key_array(key_len):
    unknown_flag = (' ' * 39 + '@flare-on.com').encode()

    key = [None] * key_len

    for i in range(51, 38, -1):
        j = i % len(key)
        if key[j] == None:
            key[j] = encrypted_data[i] ^ unknown_flag[i]

    return key


def decrypt(key_array):
    flag = [None] * 0x34
    for i in range(0x34):
        flag[i] = key_array[i % len(key_array)] ^ encrypted_data[i]

    return ''.join([chr(i) for i in flag])


print('[*] Brute forcing...')
for key_len in range(1, 0xE):
    key_array = guess_key_array(key_len)
    flag = decrypt(key_array)
    print_key(key_array)
    if flag.endswith('@flare-on.com'):
        print('\n[+] Flag: %s' % flag)
        break
