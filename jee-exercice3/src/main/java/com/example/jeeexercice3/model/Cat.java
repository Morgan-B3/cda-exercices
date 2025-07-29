package com.example.jeeexercice3.model;

import java.time.LocalDate;
import java.util.Date;

public class Cat {
    private String name;
    private String breed;
    private String food;
    //private String birthday;
    private LocalDate birthday;

    public Cat(String name, String breed, String food, LocalDate birthday) {
        this.name = name;
        this.breed = breed;
        this.food = food;
        this.birthday = birthday;
    }

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getBreed() {
        return breed;
    }
    public void setBreed(String breed) {
        this.breed = breed;
    }
    public String getFood() {
        return food;
    }
    public void setFood(String food) {
        this.food = food;
    }
    public LocalDate getBirthday() {
        return birthday;
    }
    public void setBirthday(LocalDate birthday) {
        this.birthday = birthday;
    }
}
