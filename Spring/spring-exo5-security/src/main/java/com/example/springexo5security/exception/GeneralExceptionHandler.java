package com.example.springexo5security.exception;

import com.example.springexo5security.dto.LoginResponseDto;
import com.example.springexo5security.dto.RegisterResponseDto;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

@RestControllerAdvice
public class GeneralExceptionHandler {
    @ExceptionHandler(UserAlreadyExistsException.class)
    public ResponseEntity<RegisterResponseDto> handleUserAlreadyExistsEception(UserAlreadyExistsException exception) {
        RegisterResponseDto registerResponseDto = new RegisterResponseDto();
        return new ResponseEntity<>(registerResponseDto, HttpStatus.OK);
    }

    @ExceptionHandler(NotFoundException.class)
    public ResponseEntity<LoginResponseDto> handleNotFoundException(NotFoundException exception) {
        LoginResponseDto loginResponseDto = new LoginResponseDto("NotFound");
        return new ResponseEntity<>(loginResponseDto, HttpStatus.OK);
    }
}
