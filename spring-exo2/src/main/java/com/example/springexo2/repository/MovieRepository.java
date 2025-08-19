package com.example.springexo2.repository;

import com.example.springexo2.entity.Movie;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface MovieRepository extends JpaRepository<Movie, Long> {
    public List<Movie> findByDirectorId(long id);
}
