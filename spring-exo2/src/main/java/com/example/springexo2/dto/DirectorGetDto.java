package com.example.springexo2.dto;

import com.example.springexo2.entity.Director;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class DirectorGetDto {
    private String firstName;
    private String lastName;
    private String birthDate;
    private String country;

    public Director dtoToEntity() {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        return Director.builder()
                .firstName(firstName)
                .lastName(lastName)
                .country(country)
                .birthDate(LocalDate.parse(birthDate, dtf))
                .build();
    }
}
