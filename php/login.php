<?php
//Username Stored for logging
define("USER", "user");

// Password Stored
define("PASS", "123456");
session_start();
// Normal user section - Not logged ------
        if(isset($_POST['username']) && isset($_POST['password']))
            {
                // Section for logging process -----------
                $user = trim($_POST['username']);
                $pass = trim($_POST['password']);
                if($user == USER && $pass == PASS)
                    {
                        // Successful login ------------------
                       
                        // Setting Session
                        $_SESSION['user'] = USER;
                       
                        // Redirecting to the logged page.
                        header("Location: secure.php");
                    }
                else
                    {
                        // Wrong username or Password. Show error here.
                        echo "Invalid user id or password";
                       
                    }
               
            }
            else{
              echo "No user id or password passed";
            }
?>