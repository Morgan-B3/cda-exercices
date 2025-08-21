package com.example.springexo5security.service;

import com.example.springexo5security.dto.RegisterRequestDto;
import com.example.springexo5security.entity.User;
import com.example.springexo5security.exception.UserAlreadyExistsException;
import com.example.springexo5security.repository.UserRepository;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
public class UserService {
    private final UserRepository userAppRepository;
    public UserService(UserRepository userAppRepository) {
        this.userAppRepository = userAppRepository;
    }

    public User enregistrerUtilisateur(RegisterRequestDto registerRequestDto) throws UserAlreadyExistsException {
        Optional<User> userAppOptional = userAppRepository.findByEmail(registerRequestDto.getEmail());
        // public UserApp(String firstName, String lastName, String email, String phone, String password, int role)
        if(userAppOptional.isEmpty()){
            // L'email n'est pas deja presente en bdd j'enregistre ce nouvelle user
            User user = new User(registerRequestDto.getFirstName(),
                    registerRequestDto.getLastName(),
                    registerRequestDto.getEmail(),
                    registerRequestDto.getPhone(),
                    registerRequestDto.getPassword(),
                    registerRequestDto.getRole());
            return userAppRepository.save(user);
        }
        // email present en bdd je ne peux enregistrer ce nouvelle utilisateur
        throw new UserAlreadyExistsException();
    }
}
