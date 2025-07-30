package com.example.exercice4.repository;

import com.example.exercice4.model.Dog;
import org.hibernate.Session;

import java.util.List;

public class DogRepository extends Repository<Dog> {
    public DogRepository(Session session) {
        super(session);
    }

    @Override
    public Dog findById(Integer id) {
        return _session.get(Dog.class, id);
    }

    @Override
    public List<Dog> findAll() {
        return _session.createQuery("from Dog").list();
    }
}
