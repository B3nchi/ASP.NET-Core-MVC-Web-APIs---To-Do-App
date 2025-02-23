<template>
  <div>
    <TodoItem
      v-for="todo in todos"
      :key="todo.id"
      :todo="todo"
      @toggle="$emit('toggle', $event)"
      @delete="$emit('delete', $event)"
    />
  </div>
</template>

<script>
import TodoItem from './TodoItem.vue'

export default {
  props: ['todos'],
  components: { TodoItem },
}
</script>
