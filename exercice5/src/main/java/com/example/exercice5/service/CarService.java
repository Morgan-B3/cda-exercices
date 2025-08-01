package com.example.exercice5.service;

import com.example.exercice5.model.Car;
import com.example.exercice5.repository.CarRepository;
import jakarta.enterprise.context.ApplicationScoped;
import jakarta.inject.Inject;
import org.hibernate.Incubating;
import org.hibernate.Session;
import org.hibernate.SessionFactory;

import java.util.ArrayList;
import java.util.List;

@ApplicationScoped
public class CarService implements ICarService {
    private CarRepository carRepository;
    private SessionFactory _sessionFactory;
    private Session session;


    @Override
    public List<Car> getAll(){
        List<Car> cars = new ArrayList<>();
        session = _sessionFactory.openSession();
        carRepository = new CarRepository(session);
        try {
            cars = carRepository.findAll();
        } catch (Exception ex) {
            ex.printStackTrace();
        }finally {
            session.close();
        }
        return cars;
    }

    @Override
    public Car getById(int id){
        Car car = null;
        session = _sessionFactory.openSession();
        carRepository = new CarRepository(session);
        try {
            car = carRepository.findById(id);
        } catch (Exception ex) {
            ex.printStackTrace();
        }finally {
            session.close();
        }
        return car;
    }

    @Override
    public void add(Car car){
        session = _sessionFactory.openSession();
        session.beginTransaction();
        carRepository = new CarRepository(session);
        try{
            carRepository.create(car);
            session.getTransaction().commit();
        }catch (Exception ex){
            try {
                session.getTransaction().rollback();
            }catch (Exception ex2){
                ex2.printStackTrace();
            }
        }finally {
            session.close();
        }
    }

    @Override
    public void update(int id, Car car){
        session = _sessionFactory.openSession();
        session.beginTransaction();
        carRepository = new CarRepository(session);
        try {
            carRepository.update(car);
        }catch (Exception ex){
            try {
                session.getTransaction().rollback();
            }catch (Exception ex2){
                ex2.printStackTrace();
            }
        }finally {
            session.close();
        }
    }

    @Override
    public void delete(int id){
        session = _sessionFactory.openSession();
        session.beginTransaction();
        carRepository = new CarRepository(session);
        try {
            carRepository.delete(carRepository.findById(id));
        }catch  (Exception ex){
            try {
                session.getTransaction().rollback();
            }catch (Exception ex2){
                ex2.printStackTrace();
            }
        }finally {
            session.close();
        }
    }
}
