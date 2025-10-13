package com.example.springexo4pagination.repository;

import com.example.springexo4pagination.model.Creature;
import org.springframework.data.jpa.repository.JpaRepository;

public interface CreatureRepository extends JpaRepository<Creature, Long> {
}
