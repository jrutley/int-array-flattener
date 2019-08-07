require './tail_call'
# input = [[1,2,[3],[]],4] #-> [1,2,3,4]

RubyVM::InstructionSequence.compile_option = {
  tailcall_optimization: true,
  trace_instruction: false
}

class Flattener
  # This totally didn't work with large inputs. Memory was going up like crazy.
  # Doing this iteratively is the simplest approach for someone who has coded in Ruby for a while
  extend TailCallOptimization

  #tail_recursive def helper(remaining, processed)
  def helper(remaining, processed)
    if remaining.count == 0
      processed
    else
      h, *t = remaining

      if h.kind_of?(Array)
        helper(t, processed.push(*helper(h, [])))
      else
        helper(t, processed<<h)
      end
    end
  end

  def flatten(array)
    helper(array, Array.new)
  end
end

x = Flattener.new
x.flatten([1,2,3])