package com.example.springexo2.dto;

import com.example.springexo2.entity.Director;
import com.example.springexo2.entity.Movie;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class MovieGetDto {
    private String title;
    private String releaseDate;
    private long directorId;
    private String description;
    private String genre;
    private int length;
    private Director director;

    public Movie dtoToEntity() {
        DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd/MM/yyyy");
        return Movie.builder()
                .title(title)
                .genre(genre)
                .description(description)
                .length(length)
                .director(director)
                .releaseDate(LocalDate.parse(releaseDate, dtf))
                .build();
    }
}
