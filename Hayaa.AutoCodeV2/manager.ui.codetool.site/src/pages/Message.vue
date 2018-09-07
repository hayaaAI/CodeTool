<template>
    <div style="margin-left: 15px">
    <el-table
            :data="tableData"
            stripe
            style="width: 80%">
        <el-table-column
                prop="date"
                label="日期"
                width="180">
        </el-table-column>
        <el-table-column
                prop="name"
                label="姓名"
                width="180">
        </el-table-column>
        <el-table-column
                prop="address"
                label="地址">
        </el-table-column>
    </el-table>
    </div>
</template>

<script>
    export default {
        name: "Message",
        data:function() {
            return {
                tableData: []
            }
        },
    }
</script>

<style scoped>

</style>