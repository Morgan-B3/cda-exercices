package com.example.springexo4pagination.model;

import com.example.springexo4pagination.utils.CreatureType;
import jakarta.persistence.*;
import jakarta.validation.constraints.Max;
import jakarta.validation.constraints.Min;
import jakarta.validation.constraints.Positive;
import jakarta.validation.constraints.Size;
import lombok.*;

@Entity
@Data
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class Creature {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Size(min = 1, max = 50, message = "Le nom doit faire entre 1 et 50 caractères")
    private String name;
    @Positive(message = "L'âge ne peut pas être négatif")
    private int age;
    @Positive(message = "Le poids ne peut pas être négatif")
    @Max(value = 1000, message = "Le poids ne peut dépasser 1000kg")
    private double weight;
    private boolean isDangerous;
    private CreatureType type;
}
