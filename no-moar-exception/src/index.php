<?php
ini_set('display_errors', 0);

class exploit_me  
{  
    private $cmd;

    public function __destruct()
    {
        system($this->cmd);
    }
}

$exploit_me = $_GET['exploit_me'];
var_dump($exploit_me);

if (preg_match('/\x00/', $exploit_me)) {
    die('no null');
}
else if (preg_match("/(^|;|{|})S:[0-9]+:\"/", $exploit_me)){
    die('haha nice try');
}
// else if (preg_match("/(^|;|{|})O:[0-9]+:\"/", $exploit_me)) {
//     die('almost done :D');
// }

$a = unserialize($exploit_me);
throw new Exception('nah');