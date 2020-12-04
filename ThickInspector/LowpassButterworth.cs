
namespace SInspector
{
    public class LowpassButterworth
    {
        protected ButterworthSection[] section;

        public LowpassButterworth
                (double cutoffFrequencyHz, int numSections, double Fs)
        {
            this.section = new ButterworthSection[numSections];
            for (int i = 0; i < numSections; i++)
            {
                this.section[i] = new ButterworthSection
                                    (cutoffFrequencyHz, i + 1, numSections * 2, Fs);
            }
        }
        public double compute(double input)
        {
            double output = input;
            for (int i = 0; i < this.section.Length; i++)
            {
                output = this.section[i].compute(output);
            }
            return output;
        }
    }
}

