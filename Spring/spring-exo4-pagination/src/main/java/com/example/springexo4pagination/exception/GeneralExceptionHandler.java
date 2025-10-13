package com.example.springexo4pagination.exception;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

@ControllerAdvice
public class GeneralExceptionHandler {
    @ExceptionHandler(MethodArgumentNotValidException.class)
    public ResponseEntity<List<Map<String,String>>> handleMethodArgumentNotValidException(MethodArgumentNotValidException ex){
        List<Map<String,String>> errors = ex.getFieldErrors().stream().map(fieldError -> {
            Map<String,String> error = new HashMap<>();
            error.put(fieldError.getField(), fieldError.getDefaultMessage());
            return error;
        }).toList();
        return ResponseEntity.badRequest().body(errors);
    }
}
