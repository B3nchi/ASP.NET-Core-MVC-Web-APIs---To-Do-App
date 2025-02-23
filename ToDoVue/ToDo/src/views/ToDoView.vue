<template>
  <div class="todo-container">
    <el-card class="todo-card">
      <h2>To-Do List</h2>

      <!-- Todo Form -->
      <TodoForm @add="addTodo" />

      <!-- Todo Table -->
      <el-table :data="todos" stripe border style="width: 100%" class="todo-table">
        <el-table-column prop="title" label="Title" min-width="200" />
        <el-table-column label="Completed" min-width="120" align="center">
          <template #default="{ row }">
            <el-tag :type="row.completed ? 'success' : 'danger'">
              {{ row.completed ? 'Yes' : 'No' }}
            </el-tag>
          </template>
        </el-table-column>
        <el-table-column label="Actions" min-width="180" align="center">
          <template #default="{ row }">
            <el-button
              :type="row.completed ? 'warning' : 'success'"
              size="small"
              @click="toggleTodo(row.id)"
            >
              {{ row.completed ? 'Undo' : 'Complete' }}
            </el-button>
            <el-button type="danger" size="small" @click="deleteTodo(row.id)"> Delete </el-button>
          </template>
        </el-table-column>
      </el-table>
    </el-card>
  </div>
</template>

<script>
import axios from 'axios'
import TodoForm from '@/components/TodoForm.vue'

export default {
  components: { TodoForm },
  data() {
    return {
      todos: [],
    }
  },
  methods: {
    async fetchTodos() {
      const { data } = await axios.get('https://localhost:7011/api/Todo')
      this.todos = data
    },
    async addTodo(title) {
      if (!title.trim()) return
      const { data } = await axios.post('https://localhost:7011/api/Todo', {
        title,
        completed: false,
      })
      this.todos.push(data)
    },
    async toggleTodo(id) {
      const todo = this.todos.find((t) => t.id === id)
      todo.completed = !todo.completed
      await axios.put(`https://localhost:7011/api/Todo/${id}`, todo)
    },
    async deleteTodo(id) {
      await axios.delete(`https://localhost:7011/api/Todo/${id}`)
      this.todos = this.todos.filter((t) => t.id !== id)
    },
  },
  mounted() {
    this.fetchTodos()
  },
}
</script>

<style scoped>
.todo-container {
  display: flex;
  justify-content: center;
  padding: 20px;
  background-color: #1e1e1e; /* Dark mode background */
  min-height: 100vh;
}

.todo-card {
  width: 600px;
  padding: 20px;
  background: #2c2c2c;
  border-radius: 10px;
  color: white;
}

h2 {
  text-align: center;
  margin-bottom: 20px;
}

.todo-table {
  margin-top: 20px;
}

.el-button {
  margin: 0 5px;
}
</style>
