def Fibonacci(input)
	temp= input
	if( temp == 1 || temp == 2 )
		1
	elsif
		Fibonacci( input-1 ) + Fibonacci( input-2 )
	end
end