class Song
	@@plays = 0 #used to track the number of songs played using the jukebox
	attr_reader :name, :artist, :duration
	attr_writer :duration
	
	def initialize( name, artist, duration )
		@name = name
		@artist = artist
		@duration = duration
		@play = 0 #used to track the number of times this particular song was played
	end
	
	def play
		@play += 1
		@@plays += 1
		"This song:#{@play}. Total #{@@plays}"
	end
	
	def to_s
		"Song: #{@name} -- #{@artist} (#{@duration}) "
	end
end