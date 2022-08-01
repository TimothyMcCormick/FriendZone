using System;

namespace FriendZone.Models
{
  public class Follow
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Follower { get; set; }
    public string Following { get; set; }
  }
}