using back.Models;

namespace back.HashConfiguration;


public class HashConfig{
    
    public String passwordEncoder(User user){
        string hash =  BCrypt.Net.BCrypt.HashPassword(user.Password);
        return hash;
    }

    public bool decodePassword(User user,String hash){

        bool verify = BCrypt.Net.BCrypt.Verify(user.Password,hash);
        return verify; 

    }
}