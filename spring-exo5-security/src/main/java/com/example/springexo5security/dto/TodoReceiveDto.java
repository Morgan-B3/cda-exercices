package com.example.springexo5security.dto;

import com.example.springexo5security.entity.Todo;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class TodoReceiveDto {
    private String title;
    private String description;
    private String date;

    public Todo dtoToEntity() {
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        return Todo.builder()
                .title(title)
                .description(description)
                .date(LocalDate.parse(date, formatter))
                .isDone(false)
                .build();
    }
}
