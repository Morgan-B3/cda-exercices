package com.example.springexo5security.service;

import com.example.springexo5security.dto.TodoReceiveDto;
import com.example.springexo5security.dto.TodoResponseDto;
import com.example.springexo5security.entity.Todo;
import com.example.springexo5security.repository.TodoRepository;
import jakarta.persistence.EntityNotFoundException;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class TodoService {
    private TodoRepository todoRepository;

    public TodoService(TodoRepository todoRepository) {
        this.todoRepository = todoRepository;
    }

    public TodoResponseDto getById(long id){
        return todoRepository.findById(id).orElseThrow(EntityNotFoundException::new).entityToDto();
    }

    public List<TodoResponseDto> getAll(){
        return todoRepository.findAll().stream().map(Todo::entityToDto).toList();
    }

    public TodoResponseDto create(TodoReceiveDto todoReceiveDto){
        return todoRepository.save(todoReceiveDto.dtoToEntity()).entityToDto();
    }

    public TodoResponseDto update(long id, TodoReceiveDto todoReceiveDto){
        Todo todoBefore = todoRepository.findById(id).orElseThrow(EntityNotFoundException::new);

        Todo todoAfter = todoReceiveDto.dtoToEntity();
        todoBefore.setDescription(todoAfter.getDescription());
        todoBefore.setDone(todoAfter.isDone());
        todoBefore.setDate(todoAfter.getDate());
        todoBefore.setTitle(todoAfter.getTitle());
        return todoRepository.save(todoBefore).entityToDto();
    }

    public void deleteById(long id){
        todoRepository.deleteById(id);
    }

    public TodoResponseDto completeToDo(long id){
        Todo todoBefore = todoRepository.findById(id).orElseThrow(EntityNotFoundException::new);
        todoBefore.setDone(!todoBefore.isDone());
        return todoRepository.save(todoBefore).entityToDto();
    }

    public List<TodoResponseDto> getCompleted(boolean completed){
        return todoRepository.findByIsDone(completed).stream().map(Todo::entityToDto).toList();
    }
}
