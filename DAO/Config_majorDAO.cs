﻿using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class Config_majorDAO
    {

        string conStr = "Data Source=.;Initial Catalog=HR_DB;Integrated Security=True";
        //查询
        public async Task<IEnumerable<Config_major>> Config_majorSelectAsync()
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = "select * from Config_major";
                return await connection.QueryAsync<Config_major>(sql);
            }
        }
        public async Task<IEnumerable<Config_major>> Config_majorSelectAsync(string name)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select * from Config_major where  major_kind_name='{name}'";
                return await connection.QueryAsync<Config_major>(sql);
            }
        }

        //添加
        public async Task<int> Config_majorInsertAsync(Config_major c)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"insert into Config_major(major_kind_id,major_kind_name,major_id,major_name)values((select major_kind_id from config_major_kind where Major_kind_name='{c.Major_kind_id}'),'{c.Major_kind_id}','{c.Major_id}',{c.Major_name})";
                return await connection.ExecuteAsync(sql);
            }
        }

        //删除
        public async Task<int> Config_majorDeleteAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"delete from Config_major where mak_id={id}";
                return await connection.ExecuteAsync(sql);
            }
        }
        //职位分类编号下拉框
        public async Task<IEnumerable<Config_major>> Config_majorSelectIDAsync(string name)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                string sql = $"select major_name from Config_major where major_kind_name='{name}'";
                return await connection.QueryAsync<Config_major>(sql);
            }
        }
    }
}
