package com.example.exercice5.service;

import com.example.exercice5.model.Car;
import jakarta.enterprise.context.ApplicationScoped;

import java.util.ArrayList;
import java.util.List;

@ApplicationScoped
public class CarServiceList implements ICarService{
    private List<Car> carList;

    public CarServiceList(){
        carList = new ArrayList<>();
    }

    @Override
    public List<Car> getAll(){
        return carList;
    }

    @Override
    public Car getById(int id){
        return carList.get(id-1);
    }

    @Override
    public void add(Car car){
        carList.add(car);
    }

    @Override
    public void update(int id, Car car){
        carList.set(id-1,car);
    }

    @Override
    public void delete(int id){
        carList.remove(id-1);
    }
}
