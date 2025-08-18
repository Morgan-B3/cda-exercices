package com.example.springexo1.repository;

import com.example.springexo1.entity.Todo;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public interface TodoRepository extends JpaRepository<Todo,Long> {
    public List<Todo> findByIsDone(boolean done);
}
