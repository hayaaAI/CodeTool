<template>
    <div style="margin-left: 25px">
        <div style="float: right">
            <el-button type="primary" @click="add">添加</el-button>
        </div>
        <el-table :data="tableData">
            <el-table-column
                    label="ID"
                    width="80">
                <template slot-scope="scope">
                    <span>{{ scope.row.codeTemplateId }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="名称"
                    width="120">
                <template slot-scope="scope">
                    <el-popover trigger="hover" placement="top">
                        <div style="width: 300px;overflow: auto">配置: {{ scope.row.content }}</div>
                       <div slot="reference" class="name-wrapper">
                            <el-tag size="medium">{{ scope.row.name }}</el-tag>
                        </div>
                    </el-popover>
                </template>
            </el-table-column>
            <el-table-column
                    label="代码类型"
                    width="160">
                <template slot-scope="scope">
                    <span>{{ scope.row.genCodeType }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="语言类型"
                    width="120">
                <template slot-scope="scope">
                    <span>{{ scope.row.language }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="创建时间"
                    width="180">
                <template slot-scope="scope">
                    <span>{{ scope.row.createTime }}</span>
                </template>
            </el-table-column>
            <el-table-column
                    label="更新时间"
                    width="180">
                <template slot-scope="scope">
                    <span>{{ scope.row.updateTime }}</span>
                </template>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button size="mini" @click="edit(scope.row.codeTemplateId)">编辑</el-button>
                   <el-button size="mini" type="danger" @click="del(scope.row.codeTemplateId)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
    import httphelper from '../../util/httphelper'
    import urls from '../../urlstatic'
    export default {
        name: "CodeTemplateList",
        created: function () {
            this.solutionTemplateId = this.$route.params.id;
            this.getPager(1);
        },
        data: function () {
            return {
                solutionTemplateId:0,
                pagerData: {
                    totalPage: 1
                },
                tableData: [],
                codeData:{1:"DataAccessModel",2:"Dao",4:"Service",8:"ViewService",16:"ClientService",32:"ClientView"},
                languageData:{1:"CSharp",2:"Java",4:"FSharp",8:"Go",16:"Python",128:"Html",256:"Javascript"}
            }
        },
        methods: {
            getCodeType:function(val){
                return this.codeData[val];
            },
            getLanguage:function(val){
                return this.languageData[val];
            },
            getPager: function(page) {
                var that = this;
                httphelper.authedpostform(urls.codeTemplateGetListUrl, {"solutionTemplateId": that.solutionTemplateId},
                    function (data) {
                    for(var i=0;i<data.length;i++){
                        data[i].genCodeType=that.getCodeType(data[i].genCodeType);
                        data[i].language=that.getLanguage(data[i].language);
                    }
                        that.tableData = data;
                    })
            },
            add: function() {
                var that = this;
                this.$router.push("/home/codetemplateedit/"+that.solutionTemplateId);
            },
            edit: function(id) {
                var that = this;
                this.$router.push("/home/codetemplateedit/"+that.solutionTemplateId+"/" + id);
            },
            del: function(id) {
                var that = this;
                httphelper.authedpostform(urls.codeTemplateDeleteUrl, {"id": id},
                    function (data) {
                        if(data)
                            that.$notify.success("操作成功");
                    });
            }
        }
    }
</script>

<style scoped>

</style>