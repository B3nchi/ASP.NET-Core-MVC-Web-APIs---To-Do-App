<template>
  <el-form @submit.prevent="addTodo">
    <el-input v-model="newTodo" placeholder="Add a new task" />
    <el-button type="primary" @click="addTodo">Add</el-button>
  </el-form>
</template>

<script>
export default {
  data() {
    return {
      newTodo: '',
    }
  },
  methods: {
    addTodo() {
      this.$emit('add', this.newTodo)
      this.newTodo = ''
    },
  },
}
</script>
