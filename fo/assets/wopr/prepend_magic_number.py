#!/usr/bin/python

import sys

for i in range(1, len(sys.argv)):
  missing_magic_number_file_name = str(sys.argv[i])
  with open(missing_magic_number_file_name, 'rb') as file:
    # magic number of python 3.7 b'\x42\x0D\x0D\x0A' = 3394
      pyc_file_name = missing_magic_number_file_name + '.pyc'
      magic = b'\x42\x0D\x0D\x0A\x00\x00\x00\x00\xB6\x51\x80\x5D\x10\x00\x00\x00'
      with open(pyc_file_name, 'wb') as pyc_file:
      pyc_file.write(magic)
        pyc_file.write(file.read())

  print('[+] %s is prepended.' % pyc_file_name)
