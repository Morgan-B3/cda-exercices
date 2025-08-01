package com.example.tp_hopital.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.Getter;
import lombok.NoArgsConstructor;

import java.time.LocalDate;
import java.util.List;

@Entity
@Data
@NoArgsConstructor
@AllArgsConstructor
public class Patient {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    private String lastName;
    private String firstName;
    private String imageURL;
    private LocalDate dob;
    @OneToMany(cascade = CascadeType.ALL, mappedBy = "patient")
    private List<Consultation> consultations;

    public Patient(String firstName, String lastName, String imageURL, LocalDate dob) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.imageURL = imageURL;
        this.dob = dob;
    }

}
