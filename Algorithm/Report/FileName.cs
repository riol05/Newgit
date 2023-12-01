using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Solution
{
    public bool solution(string s)
    {
        const int DefaultCapacity = 50000;
        bool answer = true;
        int close = 0;
        Stack<char> stack = new Stack<char>();

        for (int i = 0; i < s.Length; i++)
        {
            stack.Push(s[i]);
        }

        for (int i = 0; i <s.Length; i++)
        {
            char temp = stack.Pop();

            if (i == 0 && temp == ')')
            {
                answer = false;
                break;
            }
            else if (temp == '(')
            {
                close++;
            }
            else if (temp == ')')
            {
                close--;
                
            }
            
            
      
        }
        if (close != 0)
        {
            answer = false;            
        }
        return answer;

    }
    
}