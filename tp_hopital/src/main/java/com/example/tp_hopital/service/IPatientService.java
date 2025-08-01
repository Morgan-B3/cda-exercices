package com.example.tp_hopital.service;

import com.example.tp_hopital.model.Patient;

import java.util.List;

public interface IPatientService {
    List<Patient> getAllPatients();
    void addPatient(Patient patient);
    Patient getPatientById(int id);
}
