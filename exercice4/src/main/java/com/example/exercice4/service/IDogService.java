package com.example.exercice4.service;

import com.example.exercice4.model.Dog;

import java.util.List;

public interface IDogService {
    List<Dog> getAll();
    Dog getById(int id);
    void addDog(Dog dog);
    void deleteDog(Dog dog);
}
