class SongList
	MAX_SIZE = 5 * 60
	
	def SongList.is_too_long( song )
		song.duration > MAX_SIZE
	end
end