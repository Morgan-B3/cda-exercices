package com.example.springexo2.service;

import com.example.springexo2.dto.MovieGetDto;
import com.example.springexo2.entity.Movie;
import com.example.springexo2.repository.MovieRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class MovieService {
    private MovieRepository movieRepository;
    public MovieService(MovieRepository movieRepository) {
        this.movieRepository = movieRepository;
    }

    public List<Movie> findAll(){
        return movieRepository.findAll();
    }

    public Movie findById(long id){
        return movieRepository.findById(id).orElseThrow(EntityNotFoundException::new);
    }

    public List<Movie> findByDirectorId(long id){
        return movieRepository.findByDirectorId(id);
    }

    public Movie create(MovieGetDto movie){
        return movieRepository.save(movie.dtoToEntity());
    }

    public Movie update(long id, MovieGetDto movie){
        Movie updatedMovie = movieRepository.findById(id).orElseThrow(EntityNotFoundException::new);

        Movie incomingMovie = movie.dtoToEntity();
        updatedMovie.setDescription(incomingMovie.getDescription());
        updatedMovie.setTitle(incomingMovie.getTitle());
        updatedMovie.setReleaseDate(incomingMovie.getReleaseDate());
        updatedMovie.setDirector(incomingMovie.getDirector());
        updatedMovie.setLength(incomingMovie.getLength());
        updatedMovie.setGenre(incomingMovie.getGenre());
        updatedMovie.setDirector(incomingMovie.getDirector());
        return movieRepository.save(updatedMovie);
    }

    public String delete(long id){
        movieRepository.deleteById(id);
        return "Film supprimé";
    }
}
