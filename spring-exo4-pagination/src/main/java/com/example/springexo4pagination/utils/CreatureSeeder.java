package com.example.springexo4pagination.utils;

import com.example.springexo4pagination.model.Creature;
import com.example.springexo4pagination.repository.CreatureRepository;
import org.springframework.boot.CommandLineRunner;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import java.nio.charset.StandardCharsets;
import java.util.Random;
import java.util.concurrent.ThreadLocalRandom;
import java.util.stream.IntStream;

@Configuration
public class CreatureSeeder {
    @Bean
    CommandLineRunner init(CreatureRepository creatureRepository){
        return args -> {
            IntStream.range(1,50).forEach(i -> {
                Creature creature = new Creature();
                CreatureType type = CreatureType.values()[ThreadLocalRandom.current().nextInt(CreatureType.values().length)];
                byte[] array = new byte[7]; // length is bounded by 7
                new Random().nextBytes(array);
                String randomName = new String(array, StandardCharsets.UTF_8);

                creature.setType(type);
                creature.setAge(ThreadLocalRandom.current().nextInt(5,95));
                creature.setName(randomName);
                creature.setDangerous(ThreadLocalRandom.current().nextBoolean());
                creature.setWeight(ThreadLocalRandom.current().nextDouble(20,500));
                creatureRepository.save(creature);
            });
        };
    }
}
