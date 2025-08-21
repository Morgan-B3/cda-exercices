package com.example.springexo5security.entity;

import com.example.springexo5security.dto.TodoResponseDto;
import jakarta.persistence.Entity;
import jakarta.persistence.GeneratedValue;
import jakarta.persistence.GenerationType;
import jakarta.persistence.Id;
import lombok.AllArgsConstructor;
import lombok.Builder;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
@Builder
public class Todo {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String title;
    private String description;
    private LocalDate date;
    private boolean isDone;

    public TodoResponseDto entityToDto(){
        return TodoResponseDto.builder()
                .id(id)
                .title(title)
                .description(description)
                .date(date)
                .isDone(isDone)
                .build();
    }
}

