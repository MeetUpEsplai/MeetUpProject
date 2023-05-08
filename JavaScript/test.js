import { PostChat } from "./API/ServiceAPI.js";
import { Chat } from "./Modules/ChatClass.js";

var chat = new Chat("PruebaJS", "2023-05-08T08:19:21.107Z", [2, 3]);

console.log(PostChat(chat));