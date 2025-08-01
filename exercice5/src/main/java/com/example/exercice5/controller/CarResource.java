package com.example.exercice5.controller;

import com.example.exercice5.model.Car;
import com.example.exercice5.service.CarService;
import com.example.exercice5.service.CarServiceList;
import jakarta.inject.Inject;
import jakarta.ws.rs.*;
import jakarta.ws.rs.core.MediaType;
import jakarta.ws.rs.core.Response;
import org.hibernate.SessionFactory;

import java.util.ArrayList;
import java.util.List;

@Path("/cars")
public class CarResource {
    //private CarService carService;
    private CarServiceList carService;

    @Inject
    public CarResource(CarServiceList carService){
        this.carService = carService;
    }


    @GET
    @Produces(MediaType.APPLICATION_JSON)
    public List<Car> getAllCars() {
//        List<Car> cars = new ArrayList<Car>();
//        cars.add(new Car(1, "Peugeot", "206", 2005, "grise"));
//        cars.add(new Car(2, "Peugeot", "205", 2000, "rouge"));
//        return cars;
        return carService.getAll();
    }

    @GET
    @Produces(MediaType.APPLICATION_JSON)
    @Path("{id}")
    public Car getCarById(@PathParam("id") int id) {
        //return new Car(id, "Peugeot", "305", 2008, "bleue");
        return carService.getById(id);
    }

    @POST
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    public Car addCar(Car car) {
        //Car car = new Car(2, "Peugeot", "205", 2000, "rouge");
        carService.add(car);
        return car;
    }

    @PUT
    @Consumes(MediaType.APPLICATION_JSON)
    @Produces(MediaType.APPLICATION_JSON)
    @Path("{id}")
    public Car updateCar(@PathParam("id") int id, Car car) {
        carService.update(id, car);
        return car;
    }

    @DELETE
    @Path("{id}")
    @Produces(MediaType.APPLICATION_JSON)
    public String deleteCar(@PathParam("id") int id) {
        carService.delete(id);
        return "Voiture supprimée";
    }



}
