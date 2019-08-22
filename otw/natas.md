# Natas

The game can be found [here](https://overthewire.org/wargames/natas/)

### 01. Level 0 -> 1

* Click [here](http://natas0.natas.labs.overthewire.org) to login
* Username: natas0
* Password: natas0
* Use browser inspection tool to see the next level's password

### 02. Level 1 -> 2

* Click [here](http://natas1.natas.labs.overthewire.org) to login
* Username: natas1
* Password: gtVrDuiDfck831PqWsLEZy5gyDz1clto
* Use browser inspection tool to see the next level's password

### 03. Level 2 -> 3

* Click [here](http://natas2.natas.labs.overthewire.org) to login
* Username: natas2
* Password: ZluruAthQk7Q2MqmDeTiUij2ZvWy2mBi
* Inspecting the page, there is a url `files/pixel.png`
* Check the [files](http://natas2.natas.labs.overthewire.org/files/) directory, there is a file named [users.txt](http://natas2.natas.labs.overthewire.org/files/users.txt). The password of next level in in there.

### 04. Level 3 -> 4

* Click [here](http://natas3.natas.labs.overthewire.org) to login
* Username: natas3
* Password: sJIJNW6ucpu6HPZ1ZAchaDtwd7oGrD14
* When inspecting the page, we see:
```html
  <!--No more information leaks!! Not even Google will find it this time...-->
```
* Check the [robots.txt](http://natas3.natas.labs.overthewire.org/robots.txt) file. We see:
```html
User-agent: *
Disallow: /s3cr3t/
```
* Check the directory [s3cr3t](http://natas3.natas.labs.overthewire.org/s3cr3t/), there is a file named [users.txt](http://natas3.natas.labs.overthewire.org/s3cr3t/users.txt).

### 05. Level 4 -> 5

* Click [here](http://natas4.natas.labs.overthewire.org) to login
* Username: natas4
* Password: Z9tkRkWmpt9Qr7XrR5jWRkgOU901swEZ
* Inspect the page, and see the message:
```
Access disallowed. You are visiting from "http://natas4.natas.labs.overthewire.org/" while authorized users should come only from "http://natas5.natas.labs.overthewire.org/"
```
* Navigate to the [natas5](http://natas5.natas.labs.overthewire.org) page and then close the authentication box.
* Inspect the natas5 page, and add an `<a>` element as follow to change the `Referer` in the HTTP header:
```html
<a href="http://natas4.natas.labs.overthewire.org">natas4</a>
```
* Click the created link to see the next password

### 06. Level 5 -> 6

* Click [here](http://natas5.natas.labs.overthewire.org) to login
* Username: natas5
* Password: iX6IOfmpN7AYOQGPwtn3fXpbaJVJcHfq
* After logging in:
```
Access disallowed. You are not logged in
```
* Examine the cookie, we see a flag `loggedin` which is set to `0`. Let's just change that flag to `1` and then refesh the page.

### 07. Level 6 -> 7

* Click [here](http://natas6.natas.labs.overthewire.org) to login
* Username: natas6
* Password: aGoY4q2Dc6MgDq4oL4YtoKtyAg9PeHa1
* See the provided source code, there is a file `includes/secret.inc` included.
* Check that [secret.inc](http://natas6.natas.labs.overthewire.org/includes/secret.inc) file, we find the secret key.
```html
<?
$secret = "FOEIUWGHFEEUHOFUOIU";
?>
```

### 08. Level 7 -> 8

* Click [here](http://natas7.natas.labs.overthewire.org) to login
* Username: natas7
* Password: 7z3hEENjQtflzgnT29q7wAvMNfZdh0i9
* Inspect the [homepage](http://natas7.natas.labs.overthewire.org/index.php?page=home), we see:
```html
<!--  hint: password for webuser natas8 is in /etc/natas_webpass/natas8 -->
```
* Use LFI vulnerability to get the next password
* Click [here](http://natas7.natas.labs.overthewire.org/index.php?page=../../../../etc/natas_webpass/natas8)

### 09. Level 8 -> 9

* Click [here](http://natas8.natas.labs.overthewire.org) to login
* Username: natas8
* Password: DBfUBfqQG69KvJvJ1iAbMoIpwSNQ9bWe
* Check the [index-source](http://natas8.natas.labs.overthewire.org/index-source.html), we have:
```php
<?
$encodedSecret = "3d3d516343746d4d6d6c315669563362";

function encodeSecret($secret) {
    return bin2hex(strrev(base64_encode($secret)));
}

if(array_key_exists("submit", $_POST)) {
    if(encodeSecret($_POST['secret']) == $encodedSecret) {
    print "Access granted. The password for natas9 is <censored>";
    } else {
    print "Wrong secret";
    }
}
?>
```
* In the terminal, we decode the encoded secret key as below:
```shell
$ php7.3 -r 'echo base64_decode(strrev(hex2bin("3d3d516343746d4d6d6c315669563362")));'
oubWYf2kBq
```
* Submit the decoded secret to get the next password

### 10. Level 9 -> 10

* Click [here](http://natas9.natas.labs.overthewire.org) to login
* Username: natas9
* Password: W0mMhUcRRnG8dcghE4qvk3JA9lGt8nDl
* Take a look at [index-source] file, we have:
```php
$key = "";

if(array_key_exists("needle", $_REQUEST)) {
    $key = $_REQUEST["needle"];
}

if($key != "") {
    passthru("grep -i $key dictionary.txt");
}
```
* We can inject shell code below to the form get the next password:
```
needle; cat /etc/natas_webpass/natas10 #
```

### 11. Level 10 -> 11

* Click [here](http://natas10.natas.labs.overthewire.org) to login
* Username: natas10
* Password: nOpp1igQAkUzaI1GUUjzn1bFVj7xCNzu
