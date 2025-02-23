<template>
  <el-container>
    <el-header>
      <h1>To-Do List</h1>
    </el-header>
    <el-main>
      <TodoView />
    </el-main>
  </el-container>
</template>

<script>
import TodoView from './views/ToDoView.vue'

export default {
  components: { TodoView },
}
</script>
