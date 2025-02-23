<template>
  <el-card shadow="hover" class="todo-item">
    <el-checkbox :model-value="todo.completed" @change="$emit('toggle', todo.id)">
      <span :class="{ completed: todo.completed }">{{ todo.title }}</span>
    </el-checkbox>
    <el-button type="danger" size="small" @click="$emit('delete', todo.id)">
      <el-icon><Delete /></el-icon>
    </el-button>
  </el-card>
</template>

<script>
export default {
  props: ['todo'],
}
</script>

<style scoped>
.completed {
  text-decoration: line-through;
  color: gray;
}
.todo-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  padding: 10px;
  margin-bottom: 10px;
}
</style>
