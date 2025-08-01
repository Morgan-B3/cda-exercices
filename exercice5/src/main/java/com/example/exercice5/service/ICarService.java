package com.example.exercice5.service;

import com.example.exercice5.model.Car;
import jakarta.enterprise.context.ApplicationScoped;
import jakarta.ws.rs.ApplicationPath;

import java.util.List;

public interface ICarService {
    List<Car> getAll();
    Car getById(int id);
    void add(Car car);
    void update(int id,Car car);
    void delete(int id);
}
