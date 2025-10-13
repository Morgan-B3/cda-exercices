package com.example.springexo5security.repository;

import com.example.springexo5security.entity.Todo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface TodoRepository extends JpaRepository<Todo, Long> {
    public List<Todo> findByIsDone(boolean done);
}
