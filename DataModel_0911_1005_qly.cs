// 代码生成时间: 2025-09-11 10:05:10
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 数据模型命名空间
namespace DataModel
{
    // 定义用户模型
    public class User
    {
        // 用户ID，使用主键标记
        [Key]
        public int Id { get; set; }

        // 用户名，必填项
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        // 邮箱地址，必填项
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        // 密码，必填项
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        // 注释：可以添加更多的属性，如电话号码、地址等
    }

    // 定义文章模型
    public class Article
    {
        // 文章ID，使用主键标记
        [Key]
        public int Id { get; set; }

        // 文章标题，必填项
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        // 文章内容，必填项
        [Required]
        public string Content { get; set; }

        // 文章发布日期
        public DateTime PublishDate { get; set; }

        // 用户ID，与用户模型关联
        [ForeignKey("User")]
        public int UserId { get; set; }

        // 注释：添加导航属性以表示文章与用户的关系
        public virtual User User { get; set; }
    }

    // 定义评论模型
    public class Comment
    {
        // 评论ID，使用主键标记
        [Key]
        public int Id { get; set; }

        // 评论内容，必填项
        [Required]
        public string Content { get; set; }

        // 文章ID，与文章模型关联
        [ForeignKey("Article")]
        public int ArticleId { get; set; }

        // 用户ID，与用户模型关联
        [ForeignKey("User")]
        public int UserId { get; set; }

        // 注释：添加导航属性以表示评论与文章和用户的关系
        public virtual Article Article { get; set; }
        public virtual User User { get; set; }
    }

    // 注释：可以根据需要继续添加更多的数据模型，如产品、订单等
}
