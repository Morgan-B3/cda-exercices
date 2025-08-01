package com.example.exercice5.repository;

import com.example.exercice5.model.Car;
import org.hibernate.Session;

import java.util.List;

public class CarRepository extends Repository<Car> {
    public CarRepository(Session session) {
        super(session);
    }

    @Override
    public Car findById(Integer id) {
        return _session.get(Car.class, id);
    }

    @Override
    public List<Car> findAll() {
        return (List<Car>) _session.createQuery("from Car").list();
    }

    @Override
    public void delete(Car car) {}

}
