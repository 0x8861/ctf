# Bandit

The game can be found [here](https://overthewire.org/wargames/bandit/)

### 01. Level 0 -> 1

```shell
$ ssh -p 2220 bandit0@bandit.labs.overthewire.org
# password: bandit0
$ cat readme
```

### 02. Level 1 -> 2

```shell
$ ssh -p 2220 bandit1@bandit.labs.overthewire.org
# password: boJ9jbbUNNfktd78OOpsqOltutMc3MY1
$ cat < -
# or
$ cat ./-
```

### 03. Level 2 -> 3

```shell
$ ssh -p 2220 bandit2@bandit.labs.overthewire.org
# password: CV1DtqXWVFXTvM2F0k09SHz0YwRINYA9
$ cat "spaces in this filename"
```

### 04. Level 3 -> 4

```shell
$ ssh -p 2220 bandit3@bandit.labs.overthewire.org
# password: UmHadQclWmgdLOKQ3YNgjWxGoRMb5luK
$ cat ~/inhere/.hidden
```

### 05. Level 4 -> 5

```shell
$ ssh -p 2220 bandit4@bandit.labs.overthewire.org
# password: pIwrPrtPN36QITSp3EQaw936yaFoFgAB
$ cat `find ~/inhere -type f -exec file '{}' \; | grep text | cut -d ':' -f 1`
```

### 06. Level 5 -> 6

```shell
$ ssh -p 2220 bandit5@bandit.labs.overthewire.org
# password: koReBOKuIDDepwhWk7jZC0RTdopnAYKh
$ cat `find ~/inhere -type f -size 1033c -perm 640 -exec file '{}' \; | grep text | cut -d ':' -f 1`
```

### 07. Level 6 -> 7

```shell
$ ssh -p 2220 bandit6@bandit.labs.overthewire.org
# password: DXjZPULLxYr17uwoI01bNLQbtFemEgo7
$ find / -type f -user bandit7 -group bandit6 -size 33c -exec cat '{}' \; 2>/dev/null
```

### 08. Level 7 -> 8

```shell
$ ssh -p 2220 bandit7@bandit.labs.overthewire.org
# password: HKBPTKQnIay4Fw76bEy8PVxKEDQRKTzs
$ cat ~/data.txt | grep millionth
```

### 09. Level 8 -> 9

```shell
$ ssh -p 2220 bandit8@bandit.labs.overthewire.org
# password: cvX2JJa4CFALtqS87jk27qwqGhBM9plV
$ cat ~/data.txt | sort | uniq -u
```

### 10. Level 9 -> 10

```shell
$ ssh -p 2220 bandit9@bandit.labs.overthewire.org
# password: UsvVyFSfZZWbi6wgC7dAFyFuR6jQQUhR
$ cat ~/data.txt | strings | grep -E '^={10} .{32}' | cut -d ' ' -f 2
```

### 11. Level 10 -> 11

```shell
$ ssh -p 2220 bandit10@bandit.labs.overthewire.org
# password: truKLdjsbJ5g7yyJ2X2R0o3a5HQJFuLk
$ cat data.txt | base64 -d | cut -d ' ' -f 4
```

### 12. Level 11 -> 12

```shell
$ ssh -p 2220 bandit11@bandit.labs.overthewire.org
# password: IFukwKGsFW8MOq3IRFqrxE1hxTNEbUPR
$ cat ~/data.txt | tr 'N-ZA-Mn-za-m' 'A-Za-z' | cut -d ' ' -f 4
```

### 13. Level 12 -> 13

```shell
$ ssh -p 2220 bandit12@bandit.labs.overthewire.org
# password: 5Te8Y4drgCRfCx8ugdwuEX8KFC6k2EUu
$ cd `mktemp -d`
$ cat ~/data.txt | xxd -r > data
$ file data
$ mv data data.gz && gzip -d data.gz
$ bzip2 -d data
$ file data.out
$ mv data.out data.gz && gzip -d data.gz
$ file data
$ tar -xvf data && rm data
$ file data5.bin
$ tar -xvf data5.bin && rm data5.bin
$ file data6.bin
$ bzip2 -d data6.bin
$ file data6.bin.out
$ tar -xvf data6.bin.out && rm data6.bin.out
$ file data8.bin
$ mv data8.bin data8.gz && gzip -d data8.gz
$ cat data | cut -d ' ' -f 4
```

### 14. Level 13 -> 14

```shell
$ ssh -p 2220 bandit13@bandit.labs.overthewire.org
# password: 8ZjyCRiBWFYkneahHwxCv3wb2a1ORpYL
$ ssh bandit14@localhost -i ~/sshkey.privateq
$ cat /etc/bandit_pass/bandit14
```

### 15. Level 14 -> 15

```shell
$ ssh -p 2220 bandit14@bandit.labs.overthewire.org
# password: 4wcYUJFw0k0XLShlDzztnTBHiqxU3b3e
$ cat /etc/bandit_pass/bandit14 | nc localhost 30000
```

### 16. Level 15 -> 16

```shell
$ ssh -p 2220 bandit15@bandit.labs.overthewire.org
# password: BfMYroe26WYalil77FoDi9qh59eK5xNr
$ cat /etc/bandit_pass/bandit15 | openssl s_client -connect localhost:30001 --quiet
```

### 17. Level 16 -> 17

```shell
$ ssh -p 2220 bandit16@bandit.labs.overthewire.org
# password: cluFn7wTiGryunymYOu4RcffSxQluehd
$ nmap -sV -vv -p 31000-32000 localhost
$ cat /etc/bandit_pass/bandit16 | openssl s_client -connect localhost:31790 --quiet > /tmp/71level
```

### 18. Level 17 -> 18

In the level 16 shell

```shell
$ chmod 600 /tmp/71level
$ ssh bandit17@localhost -i /tmp/71level
$ diff passwords.{old,new} | grep '>' | cut -d ' ' -f 2
```

### 19. Level 18 -> 19

```shell
$ ssh -p 2220 bandit18@bandit.labs.overthewire.org /bin/bash --norc
# password: kfBf3eYk5BPBRzwjqutbbfE887SVc5Yd
$ cat readme
```

### 20. Level 19 -> 20

```shell
$ ssh -p 2220 bandit19@bandit.labs.overthewire.org
# password: IueksS7Ubh8G3DCwVzrTd8rAVOwq3M5x
$ ./bandit20-do cat /etc/bandit_pass/bandit20
```

### 21. Level 20 -> 21

```shell
$ ssh -p 2220 bandit20@bandit.labs.overthewire.org
# password: GbKksEFF4yrVs6il55v6gwY5aVje5f0j
$ nc -l -p 8861 localhost &
$ ./suconnect 8861 &
$ jobs
$ fg 1
# paste the current level password here
# the next level's password will be sent back
```

### 22. Level 21 -> 22

```shell
$ ssh -p 2220 bandit21@bandit.labs.overthewire.org
# password: gE269g2h3mw3pwgrj0Ha9Uoqen1c9DGr
$ cat $(cat `cat /etc/cron.d/cronjob_bandit22 | grep 'reboot' | cut -d ' ' -f 3` | grep 'cat' | cut -d ' ' -f 4)
```

### 23. Level 22 -> 23

```shell
$ ssh -p 2220 bandit22@bandit.labs.overthewire.org
# password: Yk7owGAcWjwMVRwrTesJEwB7WVOiILLI
$ cat `cat /etc/cron.d/cronjob_bandit23 | grep 'reboot' | cut -d ' ' -f 3`
$ cat /tmp/$(echo I am user bandit23 | md5sum | cut -d ' ' -f 1)
```

### 24. Level 23 -> 24

```shell
$ ssh -p 2220 bandit23@bandit.labs.overthewire.org
# password: jc1udXuA1tiHqjIsL8yaapX5XIAI6i0n
$ cat `cat /etc/cron.d/cronjob_bandit24 | grep 'reboot' | cut -d ' ' -f 3`
$ echo 'cat /etc/bandit_pass/bandit24 > /tmp/42level' > /var/spool/bandit24/cat-password && chmod +x /var/spool/bandit24/cat-password && sleep 61 && cat /tmp/42level
```

### 25. Level 24 -> 25

```shell
$ ssh -p 2220 bandit24@bandit.labs.overthewire.org
# password: UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ
$ cd `mktemp -d`
$ for i in `seq -f "%04g" 0 9999`; do echo UoMYTrfrBFHyQXmg6gzctqAwOmw1IohZ $i >> pass.txt; done
$ cat pass.txt | nc localhost 30002 | grep bandit25
```

### 26. Level 25 -> 26 -> 27

```shell
$ ssh -p 2220 bandit25@bandit.labs.overthewire.org
# password: uNG9O58gUE7snukf3bvZ0rxhtnjzSGzG
$ cat /etc/passwd | grep bandit26       # See default shell of user bandit26
$ cat `cat /etc/passwd | grep bandit26 | cut -d: -f7`
# The login shell will `more ~/text.txt` and then exit
# So we resize the terminal window to display only 2 or 3 lines
$ ssh bandit26@localhost -i ~/bandit26.sshkey
# Then press `v` to enter vi editor mode
# After that enter `:set shell=/bin/bash`
# Then `:shell`
$ cat /etc/bandit_pass/bandit26
$ ~/bandit27-do cat /etc/bandit_pass/bandit27
```

### 27. Level 26 -> 27

See above

### 28. Level 27 -> 28

```shell
$ ssh -p 2220 bandit27@bandit.labs.overthewire.org
# password: 3ba3118a22e93127a4ed485be72ef5ea
$ cd `mktemp -d` && git clone ssh://bandit27-git@localhost/home/bandit27-git/repo && cd repo
# password: 3ba3118a22e93127a4ed485be72ef5ea
$ cat README
```

### 29. Level 28 -> 29

```shell
$ ssh -p 2220 bandit28@bandit.labs.overthewire.org
# password: 0ef186ac70e04ea33b4c1853d2526fa2
$ cd `mktemp -d` && git clone ssh://bandit28-git@localhost/home/bandit28-git/repo && cd repo
# password: 0ef186ac70e04ea33b4c1853d2526fa2
$ git diff 073c27c 186a1
```

### 30. Level 29 -> 30

```shell
$ ssh -p 2220 bandit29@bandit.labs.overthewire.org
# password: bbc96594b4e001778eee9975372716b2
$ cd `mktemp -d` && git clone ssh://bandit29-git@localhost/home/bandit29-git/repo && cd repo
# password: bbc96594b4e001778eee9975372716b2
$ git branch --remote
$ git checkout dev
$ git log
$ git show 33ce2e95d9c5d6fb0a40e5ee9a2926903646b4e3
```

### 31. Level 30 -> 31

```shell
$ ssh -p 2220 bandit30@bandit.labs.overthewire.org
# password: 5b90576bedb2cc04c86a9e924ce42faf
$ cd `mktemp -d` && git clone ssh://bandit30-git@localhost/home/bandit30-git/repo && cd repo
# password: 5b90576bedb2cc04c86a9e924ce42faf
$ git tag   # list tags
$ git show secret
```

### 32. Level 31 -> 32

```shell
$ ssh -p 2220 bandit31@bandit.labs.overthewire.org
# password: 47e603bb428404d265f59c42920d81e5
$ cd `mktemp -d` && git clone ssh://bandit31-git@localhost/home/bandit31-git/repo && cd repo
# password: 47e603bb428404d265f59c42920d81e5
$ cat README.md
$ rm .gitignore
$ echo May I come in? > key.txt
$ git add -A
$ git commit -m "Add key file"
$ git push
```

### 33. Level 32 -> 33

```shell
$ ssh -p 2220 bandit32@bandit.labs.overthewire.org
# password: 56a9bf19c63d650ce78e6ec0354ee45e
$ cd `mktemp -d` && git clone ssh://bandit31-git@localhost/home/bandit31-git/repo && cd repo
# password: 56a9bf19c63d650ce78e6ec0354ee45e
$ $0      # Start up bash shell
$ cat /etc/bandit_pass/bandit33
```

### 34. Level 33 -> 34

```shell
$ ssh -p 2220 bandit33@bandit.labs.overthewire.org
# password: c9c3199ddf4121b10cf581a98d51caee
```