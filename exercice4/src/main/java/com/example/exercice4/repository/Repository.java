package com.example.exercice4.repository;

import com.example.exercice4.model.Dog;
import org.hibernate.Session;

import java.util.List;

public abstract class Repository<T> {
    protected Session _session;

    public Repository(Session session) {
        _session = session;
    }

    public void create(T o){
        _session.persist(o);
    };

    public void update(T o){
        _session.merge(o);
    };

    public void delete(T o){
        _session.remove(o);
    }

    abstract T findById(Integer id);

    abstract List<T> findAll();


}
