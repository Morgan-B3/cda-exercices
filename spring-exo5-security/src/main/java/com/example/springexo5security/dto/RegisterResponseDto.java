package com.example.springexo5security.dto;

import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

@NoArgsConstructor
@AllArgsConstructor
@Data
@Builder
public class RegisterResponseDto {

    private int id;
    private String firstName;
    private String lastName;
    private String email;
    private String phone;
    private String password;
    private int role;
}