class SongList
	def initialize
		@songs = Array.new
	end
	
	def append( song )
		@songs.push(song) #@songs[@songs.length] = song
		self
	end
	
	def delete_first
		@songs.shift
	end
	
	def delete_last
		@songs.pop
	end
	
	def []( index )
		@songs[index]
	end
	
	def with_title( title )
		#for i in 0..@songs.length
		#	return @songs[i] if @songs[i].name == title
		#end
		@songs.find {|song| song.name == title}
	end
end