package com.example.springexo5security.controller;

import com.example.springexo5security.dto.TodoReceiveDto;
import com.example.springexo5security.dto.TodoResponseDto;
import com.example.springexo5security.service.TodoService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/todo")
@CrossOrigin(origins = "*", methods = {RequestMethod.GET, RequestMethod.POST})
public class TodoController {
    private TodoService todoService;

    public TodoController(TodoService todoService) {
        this.todoService = todoService;
    }

    @GetMapping
    public ResponseEntity<List<TodoResponseDto>> getAll(){
        return ResponseEntity.ok(todoService.getAll());
    }

    @GetMapping("/{id}")
    public ResponseEntity<TodoResponseDto> getById(@PathVariable long id){
        return ResponseEntity.ok(todoService.getById(id));
    }

    @PostMapping
    public ResponseEntity<TodoResponseDto> create(@RequestBody TodoReceiveDto todoReceiveDto){
        return ResponseEntity.status(HttpStatus.CREATED).body(todoService.create(todoReceiveDto));
    }

    @PutMapping("/{id}")
    public ResponseEntity<TodoResponseDto> update(@PathVariable long id, @RequestBody TodoReceiveDto todoReceiveDto){
        return ResponseEntity.ok(todoService.update(id, todoReceiveDto));
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<String> delete(@PathVariable long id){
        todoService.deleteById(id);
        return ResponseEntity.ok(String.format("Todo #%d supprimé", id));
    }

    @PutMapping("/complete/{id}")
    public ResponseEntity<TodoResponseDto> completeToDo(@PathVariable long id){
        return ResponseEntity.ok(todoService.completeToDo(id));
    }

    @GetMapping("/done")
    public ResponseEntity<List<TodoResponseDto>> getDone(){
        return ResponseEntity.ok(todoService.getCompleted(true));
    }

    @GetMapping("/notdone")
    public ResponseEntity<List<TodoResponseDto>> getNotDone(){
        return ResponseEntity.ok(todoService.getCompleted(false));
    }
}
