package com.example.tp_hopital.repository;

import com.example.tp_hopital.model.Patient;
import org.hibernate.Session;

import java.util.List;

public class PatientRepository extends Repository<Patient>{
    public PatientRepository(Session session) {
        super(session);
    }

    @Override
    public Patient findById(Integer id) {
        return _session.get(Patient.class, id);
    }

    @Override
    public List<Patient> findAll() {
        return _session.createQuery("from Patient").list();
    }

    @Override
    public void delete(Patient patient) {};

    @Override
    public void update(Patient patient) {};
}
