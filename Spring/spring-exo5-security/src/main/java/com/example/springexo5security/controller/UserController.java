package com.example.springexo5security.controller;

import com.example.springexo5security.dto.LoginRequestDto;
import com.example.springexo5security.dto.LoginResponseDto;
import com.example.springexo5security.dto.RegisterRequestDto;
import com.example.springexo5security.dto.RegisterResponseDto;
import com.example.springexo5security.entity.User;
import com.example.springexo5security.exception.NotFoundException;
import com.example.springexo5security.exception.UserAlreadyExistsException;
import com.example.springexo5security.security.JWTGenerator;
import com.example.springexo5security.service.UserService;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.web.bind.annotation.*;

@RequestMapping("/api/auth")
@RestController
@CrossOrigin(origins = "*", methods = {RequestMethod.GET, RequestMethod.POST})
public class UserController {
    private final AuthenticationManager authenticationManager;

    private final UserService userService;
    private final PasswordEncoder passwordEncoder;
    private final JWTGenerator generator;

    public UserController(AuthenticationManager authenticationManager, UserService userService, PasswordEncoder passwordEncoder, JWTGenerator generator) {
        this.authenticationManager = authenticationManager;
        this.userService = userService;
        this.passwordEncoder = passwordEncoder;
        this.generator = generator;
    }


    @PostMapping("/login")
    public ResponseEntity<LoginResponseDto> login(@RequestBody LoginRequestDto loginRequestDTO) throws NotFoundException {
        try {
            Authentication authentication = authenticationManager.authenticate(new UsernamePasswordAuthenticationToken(loginRequestDTO.getEmail(), loginRequestDTO.getPassword()));
            SecurityContextHolder.getContext().setAuthentication(authentication);
            return ResponseEntity.ok(LoginResponseDto.builder().token(generator.generateToken(authentication)).build());
        }catch (Exception ex) {
            throw new NotFoundException();
        }
    }

    @PostMapping("/register")
    public ResponseEntity<RegisterResponseDto> register(@RequestBody RegisterRequestDto registerRequestDTO) throws UserAlreadyExistsException {
        registerRequestDTO.setPassword(passwordEncoder.encode(registerRequestDTO.getPassword()));
        User user = userService.enregistrerUtilisateur(registerRequestDTO);
        return ResponseEntity.ok(RegisterResponseDto.builder()
                .id(user.getId())
                .email(user.getEmail())
                .lastName(user.getLastName()).firstName(user.getFirstName())
                .phone(user.getPhone())
                .role(user.getRole().ordinal()).build());
    }
}
