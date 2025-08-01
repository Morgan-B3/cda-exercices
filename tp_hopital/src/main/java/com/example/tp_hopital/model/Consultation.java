package com.example.tp_hopital.model;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDate;

@Entity
@NoArgsConstructor
@Data
@AllArgsConstructor
public class Consultation {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private int id;
    private LocalDate date;
    private String doctorName;
    private String prescription;
    private String observation;
    @ManyToOne
    @JoinColumn(name = "patient_id")
    private Patient patient;
}
