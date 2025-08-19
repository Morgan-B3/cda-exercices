package com.example.springexo2.controller;

import com.example.springexo2.dto.MovieGetDto;
import com.example.springexo2.entity.Director;
import com.example.springexo2.entity.Movie;
import com.example.springexo2.service.DirectorService;
import com.example.springexo2.service.MovieService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("catalogue/films")
public class MovieController {
    private MovieService movieService;
    private DirectorService directorService;
    public MovieController(MovieService movieService,  DirectorService directorService) {
        this.movieService = movieService;
        this.directorService = directorService;
    }

    @GetMapping
    public ResponseEntity<List<Movie>> findAll(){
        return ResponseEntity.ok(movieService.findAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<Movie> findById(@PathVariable long id){
        return ResponseEntity.ok(movieService.findById(id));
    }

    @GetMapping("/realisateur/{id}")
    public ResponseEntity<List<Movie>> findByDirectorId(@PathVariable long id){
        return ResponseEntity.ok(movieService.findByDirectorId(id));
    }

    @PostMapping
    public ResponseEntity<Movie> save(@RequestBody MovieGetDto movie){
        Director director = directorService.findById(movie.getDirectorId());
        movie.setDirector(director);
        return ResponseEntity.ok(movieService.create(movie));
    }

    @PutMapping("/{id}")
    public ResponseEntity<Movie> update(@PathVariable long id, @RequestBody MovieGetDto movie){
        Director director = directorService.findById(movie.getDirectorId());
        movie.setDirector(director);
        return ResponseEntity.ok(movieService.update(id, movie));
    }

    @DeleteMapping("/{id}")
    public String delete(@PathVariable long id){
        return movieService.delete(id);
    }
}
